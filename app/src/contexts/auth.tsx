import React, { createContext, useState, useEffect, useContext } from 'react';
import * as auth from '../services/auth';
import api from '../services/api';

interface AuthContextData {
  signedIn: boolean;
  userId: string | null;
  signIn(email: string, password: string): Promise<void>;
  signOut(): void;
  loadedData: boolean;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({ children }) => {
  const [userId, setUserId] = useState<string | null>(null);
  const [loadedData, setLoadedData] = useState<boolean>(false);

  useEffect(() => {
    const storagedUserId = localStorage.getItem('userId');
    const storagedToken = localStorage.getItem('token');

    setUserId(storagedUserId);

    api.defaults.headers['Authorization'] = `Bearer ${storagedToken}`;

    setLoadedData(true);
  }, []);

  async function signIn(email: string, password: string) {
    const response = await auth.signIn(email, password, true);

    setUserId(response.userId);

    if (Boolean(response.userId)) {
      api.defaults.headers['Authorization'] = `Bearer ${response.token}`;

      localStorage.setItem('userId', response.userId);
      localStorage.setItem('token', response.token);
    }
  }

  function signOut() {
    setUserId(null);

    delete api.defaults.headers['Authorization'];

    localStorage.removeItem('userId');
    localStorage.removeItem('token');
  }

  return (
    <AuthContext.Provider
      value={{ signedIn: Boolean(userId), userId, signIn, signOut, loadedData }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export function useAuth() {
  const context = useContext(AuthContext);

  return context;
}
