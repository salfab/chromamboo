import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

var FontAwesome = require('react-fontawesome');

class App extends Component {

  constructor() {
      super();
      this.state = {notifications: []}
  }
  componentWillMount(){
      fetch ('http://localhost:5000/config')
      .then( response => response.json())
      .then( ({notifications: notifications})=> this.setState({notifications}) )
  }
  render(){
    let items = this.state.notifications;
    console.log(items);
    // TODO: replace this by a local version of the .css. see https://github.com/simonwhitaker/github-fork-ribbon-css
    return (
      <div className="App">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/github-fork-ribbon-css/0.2.0/gh-fork-ribbon.min.css" />
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Chromamboo configuration</h2>
        </div>
        <p className="App-intro">
           <FontAwesome
            name='plus'
            size='2x'
            spin
            style={{ textShadow: '0 1px 0 rgba(0, 0, 0, 0.1)' }}
        />
        </p>
        <div>

            {items.map(item =>
                <Wrapper key={item.displayName} headerText={item.displayName} settings={item} ribbonText={item.provider}/>
            )}
        </div>
      </div>
    );
  }
}

const Wrapper = (props)  => (
        <div className="box shadow">
            <div className="title-header">
                <h4>
                  {props.headerText}
                </h4>
                <a className="github-fork-ribbon" title={props.ribbonText} />
            </div>
            <NotificationBlock settings={props.settings} title={props.headerText} skipTitle />
        </div>);

class NotificationBlock extends Component {
    constructor() {
        super();
    }
    render() {
        let settings = this.props.settings;
        let isArray = this.props.isArray;
        let isArrayItem = this.props.isArrayItem;
        return (
            <div>
                {!this.props.skipTitle && <div className="block-title">{this.props.title}</div>}
                <div className="block-settings">
                    <ul>
                        {Object.keys(settings).map(function(keyName, keyIndex) {
                            console.log(keyName  + "  " + settings[keyName]);
                            // use keyName to get current key's name
                            // and a[keyName] or a.keyName to get its value
                            return <ValueEditor key={keyName} title={keyName} content={settings[keyName]} settings={settings} keyName={keyName} isArray={isArray} isArrayItem={isArrayItem} />
                        })}
                    </ul>
                </div>
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
        let isArray = content.constructor === Array
        if (typeof content == "object"){
            if (isArrayItem) return <SettingsBlockCollectionItem title={this.props.title} content={this.props.content} />;
            if (isArray) return <SettingsBlockCollection title={this.props.title} content={this.props.content}/>;
            return <SettingsBlock title={this.props.title} content={this.props.content}/>;
        }
        return <SettingInput label={this.props.keyName} value={this.props.content} isOptional={isArrayItem} />;
    }
}


class SettingsBlockCollection extends Component {
    constructor() {
        super();
    }
    AddItem(e){
        alert(e);
    }

    render() {
        return(
            <div>
            <li className="box nested nested-shadow">
                    <div>
                        <NotificationBlock title={this.props.title} settings={this.props.content} isNested isArrayItem />

                    </div>
                </li>
                <li className="box nested nested-shadow new-settings-block-item">
                    <a onClick={this.AddItem}>
                        +
                    </a>
                </li>
            </div>)
    }
    }


const SettingsBlockCollectionItem = (props)  => (
    <li className="box nested nested-shadow">
        <div>
            <NotificationBlock title={"Item #" + props.title} settings={props.content} isNested/>
            <a>Remove item</a>
        </div>
    </li>);

const SettingsBlock = (props)  => (
    <li className="box nested nested-shadow">
        <NotificationBlock settings={props.content} isNested isArray={props.isArray} title={props.title}/>
    </li>);

const SettingInput = (props)  => (
    <li className="setting settings-item">
        <div>
            <span className="setting-input label">{props.label}</span>: <input className="enjoy-input" value={props.value} />
            {props.isOptional && <a>X</a>}
        </div>
    </li>);


export default App;
