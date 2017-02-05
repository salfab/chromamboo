import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import 'font-awesome/css/font-awesome.css';
import 'github-fork-ribbon-css/gh-fork-ribbon.ie.css';
import 'github-fork-ribbon-css/gh-fork-ribbon.css';
import { Inject, InjectDirect } from 'react-injector';


var FontAwesome = require('react-fontawesome');

class ConfigFileManagementService {
    constructor() {
    }

    async loadNotifications(){
        var that = this;
        this.isLoading = true;

        return await fetch ('http://localhost:5000/config')
            .then( response => response.json())
            .then( ({notifications: notifications})=> {
                that.notifications = notifications;
                that.isLoading = false;
            });
    }

    updateSettingValue(jsonPath, value) {
        alert(jsonPath + " "+ value)
    }
}

class App extends Component {

  constructor(props) {
      super(props);
      this.configFileManagementService = this.props.ConfigFileManagementService;
  }
  async componentWillMount(){
      this.configFileManagementService.loadNotifications()
      .then( x => this.forceUpdate());
  }

  render(){
    let items = this.configFileManagementService.notifications;
    if(this.configFileManagementService.isLoading) {
      return <LoadingScreen />;
    }

    // TODO: replace this by a local version of the .css. see https://github.com/simonwhitaker/github-fork-ribbon-css
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Chromamboo configuration</h2>
        </div>
        <p className="App-intro">
        </p>
        <div>
<ul>
            {items.map((item, i) =>
                <Wrapper key={item.displayName} headerText={item.displayName} settings={item} ribbonText={item.provider} jsonPath={"notifications["+i+"]"}/>
            )}
    </ul>
        </div>
      </div>
    );
  }
}
InjectDirect(App, [ ConfigFileManagementService ]);

const Wrapper = (props)  => (
        <li className="box shadow">
            <div className="title-header">
                <h4>
                  {props.headerText}
                </h4>
                <a className="github-fork-ribbon" title={props.ribbonText} />
            </div>
            <NotificationBlock settings={props.settings} title={props.headerText} skipTitle jsonPath={props.jsonPath} />
        </li>);

class NotificationBlock extends Component {
    constructor() {
        super();
    }
    render() {
        let settings = this.props.settings;
        let isArray = this.props.isArray;
        let isArrayItem = this.props.isArrayItem;
        let jsonPath = this.props.jsonPath;
        return (
            <div>
                {!this.props.skipTitle && <div className="block-title">{this.props.title}</div>}
                <ul className="block-settings">
                        {Object.keys(settings).map(keyName => {
                            return <ValueEditor key={keyName} title={keyName} content={settings[keyName]} settings={settings} keyName={keyName} isArray={isArray} isArrayItem={isArrayItem} jsonPath={jsonPath} />
                        })}
                </ul>
            </div>)
    }
}

class ValueEditor extends Component {
    constructor() {
        super();
    }
    render() {
        let content = this.props.content;
        let isArrayItem = this.props.isArrayItem;
        let isArray = content.constructor === Array;
        if (typeof content == "object"){
            if (isArrayItem) return <SettingsBlockCollectionItem title={this.props.title} content={this.props.content} jsonPath={this.props.jsonPath + "[" + this.props.title+"]"} />
            if (isArray) return <SettingsBlockCollection title={this.props.title} content={this.props.content} jsonPath={this.props.jsonPath + "." + this.props.title}/>
            return <SettingsBlock title={this.props.title} content={this.props.content} jsonPath={this.props.jsonPath + "." + this.props.title} />
        }
        let jsonPath = isArrayItem ? this.props.jsonPath + "[" + this.props.keyName +"]": this.props.jsonPath + "." + this.props.keyName;
        return <SettingInput label={this.props.keyName} value={this.props.content} isOptional={isArrayItem} jsonPath={jsonPath}/>
    }
}


class SettingsBlockCollection extends Component {
    constructor() {
        super();
    }
    AddItem(e){
        alert(this.props.jsonPath);
    }

    render() {
        return(
            <ul className="box nested nested-shadow">
                <NotificationBlock title={this.props.title} settings={this.props.content} isNested isArrayItem jsonPath={this.props.jsonPath} />

                <div className="new-block-button-container">
                    <div className="box nested nested-shadow new-settings-block-item" onClick={this.AddItem.bind(this)}>
                        <a>
                        <FontAwesome name='plus'/>
                        </a>
                    </div>
                </div>

            </ul>)
    }
}


const SettingsBlockCollectionItem = (props)  => (
    <li className="box nested nested-shadow">
        <div>
            <NotificationBlock title={"Item #" + props.title} settings={props.content} isNested jsonPath={props.jsonPath}/>
            <a>Remove item</a>
        </div>
    </li>);

const SettingsBlock = (props)  => (
    <li className="box nested nested-shadow">
        <NotificationBlock settings={props.content} isNested isArray={props.isArray} title={props.title} jsonPath={props.jsonPath}/>
    </li>);

class SettingInput extends Component {
    constructor(configFileManagementService) {
        super();
        this.configFileManagementService = configFileManagementService.ConfigFileManagementService;
    }

    valueChanged(e) {
        console.log(e.target.value);
        this.configFileManagementService.updateSettingValue(this.props.jsonPath, e.target.value)
    }

    render() {
        return (
            <li className="setting settings-item">
                <span className="setting-input label">{this.props.label}</span>: <input type="text" className="enjoy-input" defaultValue={this.props.value} onChange={this.valueChanged.bind(this)} />
                {this.props.isOptional && <a><FontAwesome name='times'/></a>}
            </li>)
    }
}
const LoadingScreen = (props)  => (
    <div>
        <span>Loading</span>
    </div>);

InjectDirect(SettingInput, [ ConfigFileManagementService ]);


export default App;
