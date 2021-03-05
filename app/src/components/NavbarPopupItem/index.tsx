import React, {
  PropsWithChildren,
  Component,
  ReactNode,
  ComponentType,
} from 'react';
import { Container } from './styles';
import { Dropdown } from 'react-bootstrap';

interface NavbarPopupItemProps {
  children?: ReactNode;
  toggle: ReactNode;
}

const NavbarPopupItem: React.FC<NavbarPopupItemProps> = (props) => {
  return (
    <Container>
      <Dropdown.Toggle id="account-dropdown">{props.toggle}</Dropdown.Toggle>
      <Dropdown.Menu>{props.children}</Dropdown.Menu>
    </Container>
  );
};

export default NavbarPopupItem;
