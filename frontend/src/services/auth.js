import api from './api';
export const authService = {
  login: async (username, password) => {
    try {
      const response = await api.post('/auth/login', { username, password });
      return response.data;
    } catch (error) {
      if (error.response?.status === 400) {
        
        throw new Error(error.response.data || 'Invalid username or password.');
      }
      throw new Error('Network error. Please try again later.');
    }
  },
  
  register: async (userData) => {
    try {
      const response = await api.post('/auth/register', userData);
      return response.data;
    } catch (error) {
      if (error.response?.status === 400) {
        
        const errorMessage = error.response.data;
        if (errorMessage.includes('Username already exists')) {
          throw new Error('This username is already taken. Please choose a different one.');
        } else if (errorMessage.includes('Email already exists')) {
          throw new Error('This email is already registered. Please log in instead.');
        } else {
          throw new Error(errorMessage || 'Registration failed.');
        }
      }
      throw new Error('Network error. Please try again later.');
    }
  },
  
  getCurrentUser: () => {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  },
  
  logout: () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  },

  // forgotPassword: async (email) => {
  //   const response = await api.post('/auth/forgot-password', { email });
  //   return response.data;
  // },
  
  // validateResetToken: async (token) => {
  //   const response = await api.post('/auth/validate-reset-token', { token });
  //   return response.data;
  // },
  
  // resetPassword: async (token, email, newPassword) => {
  //   const response = await api.post('/auth/reset-password', {
  //     token,
  //     email,
  //     newPassword,
  //     confirmPassword: newPassword
  //   });
  //   return response.data;
  // }
};

