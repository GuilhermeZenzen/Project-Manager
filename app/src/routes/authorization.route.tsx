import React from 'react';
import {
  Route,
  Redirect,
  RouteProps,
  RouteComponentProps,
} from 'react-router-dom';

interface AuthorizationRouteProps extends RouteProps {
  component: React.FC<RouteComponentProps>;
  signedIn: boolean;
}

const AuthorizationRoute: React.FC<AuthorizationRouteProps> = ({
  component: Component,
  ...rest
}: AuthorizationRouteProps) => {
  return (
    <Route
      {...rest}
      render={(props: RouteComponentProps) =>
        rest.signedIn ? (
          <Redirect to={{ pathname: '/', state: { from: props.location } }} />
        ) : (
          <Component {...props} />
        )
      }
    />
  );
};

export default AuthorizationRoute;
