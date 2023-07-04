import { useState, useEffect } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./App.css";

// Páginas Públicas:
import WelcomePage from "./Pages/Welcome";
import LoginPage from "./Pages/Login";
import RegisterPage from "./Pages/Register";

// Páginas Privadas:
import ViewProductPage from "./Pages/ViewProduct";
import CatalogPage from "./Pages/Catalog";

// Componentes:
import NavBar from "./Components/NavBar";
import Footer from "./Components/Footer";

export default function App() {
  const [isAuth, setIsAuth] = useState(!!localStorage["authorization"]);

  const PrivateRoutes = createBrowserRouter([
    {
      path: "/",
      element: <CatalogPage />,
    },
    {
      path: "produto/:productID",
      element: <ViewProductPage />,
    },
  ]);

  const PublicRoutes = createBrowserRouter([
    {
      path: "/",
      element: <WelcomePage />,
    },
    {
      path: "criar-conta",
      element: <RegisterPage />,
    },
    {
      path: "login",
      element: <LoginPage setIsAuth={setIsAuth} />,
    },
  ]);

  return (
    <>
      {isAuth && <NavBar />}

      <div className="p-5">
        <RouterProvider router={isAuth ? PrivateRoutes : PublicRoutes} />
      </div>

      {isAuth && <Footer />}
    </>
  );
}
