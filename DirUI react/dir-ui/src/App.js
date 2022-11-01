import React from "react";
import { HashRouter as Router, Route, Switch } from 'react-router-dom'
import './App.css';
import Directory from "./Components/Directory";
import Home from "./Components/Home";
import Manage from "./Components/Manage";
import NavBar from "./Components/NavBar";

function App() {
  return (
    <>
    
    
      <Router>
      <NavBar></NavBar>
         <div className="App">
         <Switch>
           <Route exact path="/" component={Home}/>
           <Route   path="/dir/*"
           
           render={props => {
            
            return (
              <Directory
                key={Date().toLocaleString()}
                {...props}
              />
            );
          }}/>
           <Route   path="/manage" component={Manage}/>
           <Route render={()=><div>Page not found</div>} />
          </Switch>
          </div>
      </Router>
      </>
  );
}

export default App;
