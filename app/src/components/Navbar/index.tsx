import React, { useState } from 'react';
import { Container } from './styles';
import { useHistory } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faBell } from '@fortawesome/free-solid-svg-icons';
import theme from '../../styles/themes/dark';

import { Dropdown } from 'react-bootstrap';

import NavbarItem from '../NavbarItem';
import NavbarPopupItem from '../NavbarPopupItem';

import { useAuth } from '../../contexts/auth';

const Navbar: React.FC = (props) => {
  const auth = useAuth();
  const history = useHistory();

  const redirect = (path: string) => {
    history.push(path);
  };

  const handleSignOut = () => {
    auth.signOut();
  };

  return (
    <Container>
      <div className="path-items">
        <NavbarItem title="Dashboard" path="/" onSelected={redirect} />
        <NavbarItem title="Personnel" path="/personnel" onSelected={redirect} />
        <NavbarItem title="Projects" path="/projects" onSelected={redirect} />
      </div>
      <div className="popup-items">
        <NavbarPopupItem
          toggle={
            <FontAwesomeIcon
              icon={faBell}
              color={theme.colors.lightText}
              size="lg"
            />
          }
        ></NavbarPopupItem>
        <NavbarPopupItem
          toggle={
            <FontAwesomeIcon
              icon={faUser}
              color={theme.colors.lightText}
              size="lg"
            />
          }
        >
          <Dropdown.Item onClick={() => redirect('/account/change-email')}>
            Change Email
          </Dropdown.Item>
          <Dropdown.Item onClick={() => redirect('/account/change-password')}>
            Change Password
          </Dropdown.Item>
          <Dropdown.Item onClick={() => redirect('/account/delete')}>
            Delete Account
          </Dropdown.Item>
          <Dropdown.Item onClick={handleSignOut}>Sign Out</Dropdown.Item>
        </NavbarPopupItem>
      </div>
    </Container>
  );
};

export default Navbar;
