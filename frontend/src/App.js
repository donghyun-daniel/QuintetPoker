import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import Settings from './components/Settings';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li><Link to="/">Home</Link></li>
            {isLoggedIn ? (
              <>
                <li><Link to="/settings">Settings</Link></li>
                <li><button onClick={() => setIsLoggedIn(false)}>Logout</button></li>
              </>
            ) : (
              <li><Link to="/login">Login</Link></li>
            )}
          </ul>
        </nav>

        <Switch>
          <Route path="/login">
            <LoginForm setIsLoggedIn={setIsLoggedIn} />
          </Route>
          <Route path="/settings">
            <Settings />
          </Route>
          <Route path="/">
            <h1>Welcome to Quintet Poker</h1>
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
