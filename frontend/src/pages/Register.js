
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { authService } from '../services/auth';

const Register = () => {
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: ''
  });
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
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
    setSuccess('');

    if (!formData.username || !formData.email || !formData.password) {
      setError('Please fill in all fields');
      setLoading(false);
      return;
    }

    if (formData.password.length < 6) {
      setError('Password must be at least 6 characters long');
      setLoading(false);
      return;
    }

    try {
      await authService.register(formData);
      setSuccess('Registration successful! Please log in.');
      setTimeout(() => {
        navigate('/login');
      }, 2000);
    } catch (err) {
      
      setError(err.message || 'Registration failed. Please try again later.');
      console.error('Registration error:', err);
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
              <h3 className="card-title text-center mb-4">Register for BlogCMS</h3>
              
              {success && (
                <div className="alert alert-success text-center">
                  {success}
                  <div className="mt-2">
                    <Link to="/login" className="btn btn-primary">Go to Login</Link>
                  </div>
                </div>
              )}
              
              {error && (
                <div className="alert alert-danger text-center">
                  {error}
                  {error.includes('already registered') && (
                    <div className="mt-2">
                      <Link to="/login" className="btn btn-primary">Go to Login</Link>
                    </div>
                  )}
                </div>
              )}
              
              {!success && (
                <form onSubmit={handleSubmit}>
                  <div className="mb-3">
                    <label htmlFor="username" className="form-label visually-hidden">Username *</label>
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
                  <div className="mb-3">
                    <label htmlFor="email" className="form-label visually-hidden">Email *</label>
                    <input
                      type="email"
                      className="form-control form-control-lg"
                      id="email"
                      name="email"
                      value={formData.email}
                      onChange={handleChange}
                      placeholder="Email"
                      required
                    />
                  </div>
                  <div className="mb-4">
                    <label htmlFor="password" className="form-label visually-hidden">Password *</label>
                    <input
                      type="password"
                      className="form-control form-control-lg"
                      id="password"
                      name="password"
                      value={formData.password}
                      onChange={handleChange}
                      placeholder="Password"
                      required
                      minLength={6}
                    />
                    <div className="form-text text-start text-muted mt-2">Password must be at least 6 characters long.</div>
                  </div>
                  <button type="submit" className="btn btn-primary btn-lg w-100 mb-3" disabled={loading}>
                    {loading ? (
                      <>
                        <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
                        Registering...
                      </>
                    ) : (
                      'Register'
                    )}
                  </button>
                </form>
              )}
              
              <div className="text-center mt-3">
                <p className="text-muted">Already have an account? <Link to="/login" className="text-decoration-none fw-bold">Login here</Link></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Register;
