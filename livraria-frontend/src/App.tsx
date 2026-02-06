import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Home } from "./pages/Home";
import { Livros } from "./pages/Livros";
import { MainLayout } from "./layouts/MainLayout";
import { Login } from "./pages/Login";
import { Register } from "./pages/Register";
import { Autor } from "./pages/Autores";
import { ConfirmarEmail } from "./components/ConfirmarEmail";
import { AuthProvider } from "./contexts/AuthContext";
import { CartProvider } from "./contexts/CartContext";
import { Navbar } from "./components/Navbar";
import { Carrinho } from "./pages/Carrinho";

export function App() {
  return (
    <AuthProvider>
      <CartProvider>
        <BrowserRouter>
          <Navbar />
          <Routes >                 
          <Route path="/" element={<Home />} />
          <Route path="/livros" element={<Livros />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/autores" element={<Autor />} />
          <Route path="/confirmar-email" element={<ConfirmarEmail />} />
          <Route path="/carrinho" element={<Carrinho />} />
          </Routes>
        </BrowserRouter>
      </CartProvider>
    </AuthProvider>
  );
}

export default App;
