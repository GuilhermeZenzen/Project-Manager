import styled from 'styled-components';

export const Container = styled.div`
  background: ${(props) => props.theme.colors.primary};
  width: 100vw;
  height: 50px;

  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 0 20px;
  overflow: visible;
  box-sizing: border-box;

  > div {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    height: 100%;
  }
`;
