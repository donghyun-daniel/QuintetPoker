import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import Settings from './components/Settings';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    // Check if user is logged in
    fetch('http://localhost:8000/accounts/user/', { credentials: 'include' })
      .then(response => response.json())
      .then(data => {
        if (data.username) {
          setIsLoggedIn(true);
        }
      });
  }, []);

  return (
    <Router>
      {/* ... rest of your component */}
    </Router>
  );
}

export default App;
