import styled from 'styled-components';

export const Container = styled.div`
  width: 140px;
  height: 100%;
  color: ${(props) => props.theme.colors.lightText};
  display: flex;
  flex-direction: column;
  justify-content: center;
  cursor: pointer;

  h2 {
    font-size: 1.5rem;
    text-align: center;
  }

  &:hover {
    border-bottom: 2px ${(props) => props.theme.colors.lightText} solid;
  }

  &.selected {
    border-bottom: 2px ${(props) => props.theme.colors.tertiary} solid;

    h2 {
      color: ${(props) => props.theme.colors.tertiary};
    }
  }
`;
