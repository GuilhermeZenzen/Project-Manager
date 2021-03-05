import api from './api';

interface SignInResponse {
  userId: string;
  token: string;
}

export async function signIn(
  email: string,
  password: string,
  fake: boolean
): Promise<SignInResponse> {
  if (fake) {
    return { userId: 'userId', token: 'token' };
  }

  const response = api.post('/sign-in', {
    email,
    password,
  });

  const responseData: SignInResponse = (await response).data;

  return responseData;
}
