import React from 'react';
import {
  Route,
  Redirect,
  RouteProps,
  RouteComponentProps,
} from 'react-router-dom';
import { useAuth } from '../contexts/auth';

interface ProtectedRouteProps extends RouteProps {
  component: React.FC<RouteComponentProps>;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({
  component: Component,
  ...rest
}: ProtectedRouteProps) => {
  const redirectPath = '/auth/sign-in';
  const auth = useAuth();

  return (
    <Route
      {...rest}
      render={(props: RouteComponentProps) =>
        auth.signedIn ? (
          <Component {...props} />
        ) : (
          auth.loadedData && (
            <Redirect
              to={{ pathname: redirectPath, state: { from: props.location } }}
            />
          )
        )
      }
    />
  );
};

export default ProtectedRoute;
