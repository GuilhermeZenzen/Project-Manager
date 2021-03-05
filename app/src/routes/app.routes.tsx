import React from 'react';

import ProtectedRoute from './protected.route';

const AppRoutes: React.FC = () => {
  return (
    <>
      <ProtectedRoute exact path="/" component={() => <h2>Home</h2>} />
      <ProtectedRoute path="/personnel" component={() => <h2>Personnel</h2>} />
      <ProtectedRoute path="/projects" component={() => <h2>Projects</h2>} />
      <ProtectedRoute
        path="/account/change-email"
        component={() => <h2>Change Email</h2>}
      />
      <ProtectedRoute
        path="/account/change-password"
        component={() => <h2>Change Password</h2>}
      />
      <ProtectedRoute
        path="/account/delete"
        component={() => <h2>Delete Account</h2>}
      />
    </>
  );
};

export default AppRoutes;
