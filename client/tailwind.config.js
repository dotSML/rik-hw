/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,jsx,ts,tsx}'],
  theme: {
    extend: {
      colors: {
        primaryGrey: '#eef2f5',
        primaryBlue: '#005aa1',
        darkGrey: '#373737',
        textPrimary: '#424242',
      },
    },
  },
  plugins: [],
};
