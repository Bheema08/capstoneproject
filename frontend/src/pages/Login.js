import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { authService } from '../services/auth';

const Login = () => {
  const [formData, setFormData] = useState({
    username: '',
    password: ''
  });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
    if (error) setError(''); 
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    try {
      const response = await authService.login(formData.username, formData.password);
      localStorage.setItem('token', response.token);
      localStorage.setItem('user', JSON.stringify(response.user));
      navigate('/dashboard');
    } catch (error) {
      setError(error.message || 'Login failed'); 
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container mt-5 d-flex justify-content-center align-items-center" style={{ minHeight: 'calc(100vh - 80px)' }}>
      <div className="row justify-content-center w-100">
        <div className="col-md-6 col-lg-5">
          <div className="card shadow-lg"> 
            <div className="card-body p-4 p-md-5"> 
              <h3 className="card-title text-center mb-4">Login to BlogCMS</h3> 
              {error && <div className="alert alert-danger">{error}</div>}
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <label htmlFor="username" className="form-label visually-hidden">Username</label> {/* Visually hidden label */}
                  <input
                    type="text"
                    className="form-control form-control-lg" 
                    id="username"
                    name="username"
                    value={formData.username}
                    onChange={handleChange}
                    placeholder="Username" 
                    required
                  />
                </div>
                <div className="mb-4"> 
                  <label htmlFor="password" className="form-label visually-hidden">Password</label> 
                  <input
                    type="password"
                    className="form-control form-control-lg" 
                    id="password"
                    name="password"
                    value={formData.password}
                    onChange={handleChange}
                    placeholder="Password" 
                    required
                  />
                </div>
                <button type="submit" className="btn btn-primary btn-lg w-100 mb-3" disabled={loading}>
                  {loading ? (
                    <>
                      <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
                      Logging in...
                    </>
                  ) : 'Login'}
                </button>
              </form>
              <div className="text-center mt-3">
                <p className="text-muted">Don't have an account? <Link to="/register" className="text-decoration-none fw-bold">Register here</Link></p>
                
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
