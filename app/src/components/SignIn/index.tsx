import React, { useRef, FormEvent } from 'react';
import { Form, FormControl, Button, Nav } from 'react-bootstrap';
import { SignInContainer } from './styles';
import { useAuth } from '../../contexts/auth';

const SignIn: React.FC = () => {
  const { signIn } = useAuth();

  const emailRef = useRef<HTMLInputElement & FormControl>(null);
  const passwordRef = useRef<HTMLInputElement & FormControl>(null);

  function handleSignIn(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    signIn(emailRef.current?.value ?? '', passwordRef.current?.value ?? '');
  }

  return (
    <SignInContainer>
      <h2>Sign In</h2>
      <Form className="form" onSubmit={handleSignIn}>
        <Form.Group controlId="emailGroup">
          <Form.Label>Email</Form.Label>
          <Form.Control type="email" ref={emailRef} />
        </Form.Group>
        <Form.Group controlId="passwordGroup">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" ref={passwordRef} />
        </Form.Group>

        <div className="submit-or-create-account-container">
          <Button variant="primary" type="submit">
            Sign In
          </Button>
          <Nav>
            <Nav.Item>
              <Nav.Link href="/auth/sign-up">Create Account</Nav.Link>
            </Nav.Item>
          </Nav>
        </div>
      </Form>
    </SignInContainer>
  );
};

export default SignIn;
