function applyTheme() {
    const isDarkMode = localStorage.getItem('darkMode') === 'true';
    document.documentElement.classList.toggle('dark-mode', isDarkMode);
    
    // Update toggle if it exists on the page
    const toggle = document.getElementById('dark-mode-toggle');
    if (toggle) {
        toggle.checked = isDarkMode;
    }
}

function toggleDarkMode() {
    const isDarkMode = document.documentElement.classList.toggle('dark-mode');
    localStorage.setItem('darkMode', isDarkMode);
    
    // Update toggle
    const toggle = document.getElementById('dark-mode-toggle');
    if (toggle) {
        toggle.checked = isDarkMode;
    }
}

// Apply theme on page load
document.addEventListener('DOMContentLoaded', applyTheme);

// Expose toggleDarkMode to global scope
window.toggleDarkMode = toggleDarkMode;
