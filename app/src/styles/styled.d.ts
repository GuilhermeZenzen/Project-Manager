import 'styled-components';

declare module 'styled-components' {
  export interface DefaultTheme {
    title: string;

    colors: {
      background: string;
      lightText: string;
      darkText: string;

      primary: string;
      secondary: string;
      tertiary: string;
    };
  }
}
