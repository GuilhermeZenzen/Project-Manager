import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import GlobalStyle from './styles/styles';
import { AuthProvider } from './contexts/auth';

import AuthRoutes from './routes/auth.routes';
import AppRoutes from './routes/app.routes';
import Navbar from './components/Navbar';
import { ThemeProvider } from 'styled-components';

import darkTheme from './styles/themes/dark';

const App: React.FC = () => {
  return (
    <ThemeProvider theme={darkTheme}>
      <GlobalStyle />
      <AuthProvider>
        <BrowserRouter>
          <Switch>
            <Route path="/auth" component={AuthRoutes} />
            <Route
              path="/"
              component={() => (
                <>
                  <Navbar />
                  <AppRoutes />
                </>
              )}
            />
          </Switch>
        </BrowserRouter>
      </AuthProvider>
    </ThemeProvider>
  );
};

export default App;
