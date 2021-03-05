import React from 'react';

import AuthorizationRoute from './authorization.route';
import SignIn from '../components/SignIn';
import SignUp from '../components/Signup';
import { useAuth } from '../contexts/auth';

const AuthRoutes: React.FC = () => {
  const { signedIn } = useAuth();

  return (
    <>
      <AuthorizationRoute
        exact
        path="/auth/sign-in"
        component={SignIn}
        signedIn={signedIn}
      />
      <AuthorizationRoute
        exact
        path="/auth/sign-up"
        component={SignUp}
        signedIn={signedIn}
      />
    </>
  );
};

export default AuthRoutes;
