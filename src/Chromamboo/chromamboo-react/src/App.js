import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import createFragment from 'react-addons-create-fragment'

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
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Chromamboo configuration</h2>
        </div>
        <p className="App-intro">
            Current configuration
        </p>
        <div>

            {items.map(item =>
                <Wrapper key={item.displayName} headerText={item.displayName} settings={item} />
            )}
        </div>
      </div>
    );
  }
}

const Wrapper = (props)  => (
        <div className="box shadow">
          <h4>
              {props.headerText}
          </h4>
            <NotificationBlock settings={props.settings} title={props.headerText} />
        </div>)

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
              Title: {this.props.title}
                <ul>
                    {Object.keys(settings).map(function(keyName, keyIndex) {
                        console.log(keyName  + "  " + settings[keyName]);
                        // use keyName to get current key's name
                        // and a[keyName] or a.keyName to get its value
                        return <ValueEditor title={keyName} content={settings[keyName]} settings={settings} keyName={keyName} isArray={isArray} isArrayItem={isArrayItem} />
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
        let isArray = content.constructor === Array
        if (typeof content == "object"){
            if (isArrayItem) {
                return (
                    <li className="box nested nested-shadow">
                      <div>
                          <NotificationBlock title={"Item #" + this.props.title}settings={content} isNested/>
                          <button>Remove item</button>
                      </div>
                    </li>)

            }
            if (isArray) {
                return (
                    <li className="box nested nested-shadow">
                      <div>
                          <NotificationBlock title={this.props.title} settings={content} isNested isArrayItem="true" />
                          <button>Add new item</button>
                      </div>
                    </li>)

            }
            return (
            <li className="box nested nested-shadow">
                 object: {this.props.keyName}
                <NotificationBlock settings={content} isNested isArray={isArray}/>
            </li>)
        }
        if (isArrayItem) {
          return(              
                <div>
                    scalar array Item: <b>{this.props.keyName}</b>: {this.props.content} <button>X</button>
                </div>)
        }
        return(
              <div>
                  scalar: <b>{this.props.keyName}</b>: {this.props.content}
              </div>)
    }
}

export default App;
