import styled from 'styled-components';
import { shade } from 'polished';

export const SignInContainer = styled.div`
  width: 35vw;
  height: 100vh;
  margin: 0 auto;
  padding: 80px 40px;
  background-color: ${(props) => props.theme.colors.primary};
  box-shadow: 1px 1px 5px ${(props) => shade(0.3, props.theme.colors.secondary)};

  h2 {
    color: ${(props) => props.theme.colors.lightText};
    text-align: center;
    margin-bottom: 80px;
  }

  .form-label {
    color: ${(props) => props.theme.colors.lightText};
  }

  .form-control {
    background-color: ${(props) => props.theme.colors.primary};
    border-color: ${(props) => props.theme.colors.secondary};
    color: ${(props) => props.theme.colors.lightText};
  }

  .submit-or-create-account-container {
    display: flex;
    flex-direction: row;
    justify-content: space-between;

    .nav-link {
      padding-right: 3px;
    }
  }
`;
