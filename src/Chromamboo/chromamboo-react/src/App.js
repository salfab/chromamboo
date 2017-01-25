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
                <Wrapper key={item.displayName} settings={item} />
            )}
        </div>
      </div>
    );
  }
}

const Wrapper = (props)  => (
        <div className="box shadow">
            <NotificationBlock settings={props.settings} />
        </div>)

class NotificationBlock extends Component {
    constructor() {
        super();
    }
    render() {
        let settings = this.props.settings;
        let isNested = this.props.isNested;
        return (
            <div>
                <h4>
                    {settings.displayName}
                </h4>
                <ul>
                    {Object.keys(settings).map(function(keyName, keyIndex) {
                        console.log(keyName  + "  " + settings[keyName]);
                        // use keyName to get current key's name
                        // and a[keyName] or a.keyName to get its value
                        return <ValueEditor content={settings[keyName]} settings={settings} keyName={keyName} />
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
        if (typeof content == "object"){
            return (
            <li className="box nested">
                {this.props.keyName}
                <NotificationBlock settings={content} isNested="true"/>
            </li>)
        }
        return(
            <li>
        <div>
            {this.props.content}
        </div>
                </li>)
    }
}

export default App;
