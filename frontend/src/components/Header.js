import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { authService } from '../services/auth';
import './Header.css'; 

const Header = () => {
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const navigate = useNavigate();
  const user = authService.getCurrentUser();

  const handleLogout = () => {
    authService.logout();
    navigate('/');
    
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-primary-custom sticky-top"> 
      <div className="container">
        <Link className="navbar-brand fs-4 fw-bold" to={user ? "/home" : "/"}>BlogCMS</Link>
        
        {user && (
          <>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarNav">
              <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                <li className="nav-item">
                  <Link className="nav-link" aria-current="page" to="/home">Home</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/dashboard">Dashboard</Link>
                </li>
                {user.role === 'Admin' && (
                  <li className="nav-item">
                    <Link className="nav-link" to="/admin">Admin</Link>
                  </li>
                )}
              </ul>
              <ul className="navbar-nav">
                <li className={`nav-item dropdown ${dropdownOpen ? 'show' : ''}`}>
                  <a 
                    className="nav-link dropdown-toggle" 
                    href="#" 
                    role="button" 
                    onClick={() => setDropdownOpen(!dropdownOpen)}
                    aria-expanded={dropdownOpen ? "true" : "false"}
                    style={{ cursor: 'pointer' }}
                  >
                    {user.username}
                  </a>
                  <ul className={`dropdown-menu ${dropdownOpen ? 'show' : ''}`} style={{position: 'absolute', inset: '0px auto auto 0px', margin: '0px', transform: 'translate(0px, 40px)'}}>
                    <li><hr className="dropdown-divider" /></li>
                    <li>
                      <button className="dropdown-item" onClick={handleLogout} style={{ cursor: 'pointer' }}>
                        Logout
                      </button>
                    </li>
                  </ul>
                </li>
              </ul>
            </div>
          </>
        )}
      </div>
    </nav>
  );
};

export default Header;
