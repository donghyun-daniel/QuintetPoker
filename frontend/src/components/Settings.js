import React, { useState } from 'react';

function Settings() {
  const [darkMode, setDarkMode] = useState(false);

  const toggleDarkMode = () => {
    setDarkMode(!darkMode);
    // Here you would typically update the theme in your app
    document.body.classList.toggle('dark-mode');
  };

  return (
    <div>
      <h2>Settings</h2>
      <label>
        Dark Mode:
        <input
          type="checkbox"
          checked={darkMode}
          onChange={toggleDarkMode}
        />
      </label>
    </div>
  );
}

export default Settings;
