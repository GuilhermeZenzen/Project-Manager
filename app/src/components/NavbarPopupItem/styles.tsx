import styled from 'styled-components';
import { Dropdown } from 'react-bootstrap';

export const Container = styled(Dropdown)`
  width: 100px;
  height: 100%;
  color: ${(props) => props.theme.colors.lightText};
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  align-self: right;
  cursor: pointer;
  outline: none;

  &:hover {
    border-bottom: 2px ${(props) => props.theme.colors.lightText} solid;
  }

  &.selected {
    border-bottom: 2px ${(props) => props.theme.colors.tertiary} solid;
  }

  &.show .dropdown-toggle {
    border-radius: 0;
  }

  .dropdown-toggle {
    width: 100%;
    height: 100%;
    background: #0000;
    border: none;

    &:focus {
      box-shadow: none !important;
      border-radius: 0;
    }
  }
`;
