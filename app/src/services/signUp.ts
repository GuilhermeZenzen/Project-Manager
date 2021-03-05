import api from './api';

interface SignUpError {
  errorName: string;
  errorMessage: string;
}

interface SignUpResponse {
  succeeded: boolean;
  errors: SignUpError[];
}

async function signUp(
  firstName: string,
  lastName: string,
  email: string,
  password: string,
  confirmedPassword: string
): Promise<SignUpResponse> {
  const response = api.post('/sign-up', {
    firstName,
    lastName,
    email,
    password,
    confirmedPassword,
  });

  const responseData: SignUpResponse = (await response).data;

  return responseData;
}

export default signUp;
