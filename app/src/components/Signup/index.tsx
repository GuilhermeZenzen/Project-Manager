import React, { useRef, FormEventHandler, FormEvent } from 'react';
import signUp from '../../services/signUp';
import { useAuth } from '../../contexts/auth';
import { Form, FormControl, Button, Nav } from 'react-bootstrap';
import { SignUpContainer } from './styles';

const SignUp: React.FC = () => {
  const { signIn } = useAuth();

  const firstNameRef = useRef<FormControl & HTMLInputElement>(null);
  const lastNameRef = useRef<FormControl & HTMLInputElement>(null);
  const emailRef = useRef<FormControl & HTMLInputElement>(null);
  const passwordRef = useRef<FormControl & HTMLInputElement>(null);
  const confirmedPasswordRef = useRef<FormControl & HTMLInputElement>(null);

  const handleSignUp = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const email = emailRef.current?.value ?? '';
    const password = passwordRef.current?.value ?? '';

    const response = await signUp(
      firstNameRef.current?.value ?? '',
      lastNameRef.current?.value ?? '',
      email,
      password,
      confirmedPasswordRef.current?.value ?? ''
    );

    if (response.succeeded) {
      signIn(email, password);
    }
  };

  return (
    <SignUpContainer>
      <h2>Create Account</h2>
      <Form onSubmit={handleSignUp}>
        <Form.Group controlId="firstNameGroup">
          <Form.Label>First Name</Form.Label>
          <Form.Control type="text" ref={firstNameRef} />
        </Form.Group>
        <Form.Group controlId="lastNameGroup">
          <Form.Label>Last Name</Form.Label>
          <Form.Control type="text" ref={lastNameRef} />
        </Form.Group>
        <Form.Group controlId="emailGroup">
          <Form.Label>Email</Form.Label>
          <Form.Control type="email" ref={emailRef} />
        </Form.Group>
        <Form.Group controlId="passwordGroup">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" ref={passwordRef} />
        </Form.Group>
        <Form.Group controlId="confirmedPasswordGroup">
          <Form.Label>Confirm Password</Form.Label>
          <Form.Control type="password" ref={confirmedPasswordRef} />
        </Form.Group>
        <div className="submit-or-sign-in-container">
          <Button variant="primary" type="submit">
            Create Account
          </Button>
          <Nav>
            <Nav.Item>
              <Nav.Link href="/auth/sign-in">Sign In</Nav.Link>
            </Nav.Item>
          </Nav>
        </div>
      </Form>
    </SignUpContainer>
  );
};

export default SignUp;
