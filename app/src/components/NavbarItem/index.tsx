import React from 'react';

import { Container } from './styles';
import { useLocation } from 'react-router';

interface NavbarItemProps {
  title: string;
  path: string;
  onSelected(path: string): void;
}

const NavbarItem: React.FC<NavbarItemProps> = (props) => {
  const location = useLocation();

  const select = () => {
    props.onSelected(props.path);
  };

  return (
    <Container
      className={`navbar-item ${
        location.pathname === props.path ? 'selected' : ''
      }`}
      onClick={select}
    >
      <h2>{props.title}</h2>
    </Container>
  );
};

export default NavbarItem;
