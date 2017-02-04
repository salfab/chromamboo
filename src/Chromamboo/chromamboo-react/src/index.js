import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { ReactInjector } from 'react-injector'

ReactDOM.render(
    (<ReactInjector>
        <App />
    </ReactInjector>),
  document.getElementById('root')
);
