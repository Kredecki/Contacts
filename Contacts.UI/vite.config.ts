import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

//Konfigurujemy vite, aby połączyć go z serwerem API.
// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
    vue()
  ],
  server: {
    proxy: {
      '/api': {
        target: "https://localhost:7291", //Adres oraz port serwera api. Można to jeszcze rozdzielic dodając poniżej znacznik "port: 7291"
        changeOrigin: true, //Gdy ustawione na true, zmienia źródło zapytań w celu dopasowania do docelowego serwera.
        secure: true, //jeśli ustawione na false, wyłącza wymaganie, aby komunikacja była zabezpieczona (HTTPS).
        rewrite: path => path.replace('/api', ''), //aby podmieniało nam '/api' na ' https://localhost:7291 '
      }
    },
  },
  resolve: {
    alias: [{ find: '@', replacement: '/src' }], //Alias do ścieżek, aby zaczynać od src.
   },
})