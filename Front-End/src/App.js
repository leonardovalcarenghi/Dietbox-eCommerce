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
import Error404Page from "./Pages/Error404";
import NewProductPage from "./Pages/NewProduct";

export default function App() {
  const [isAuth, setIsAuth] = useState(!!localStorage["authorization"]);
  const [isCompany, setIsCompany] = useState(localStorage["loginAs"] == 2);

  const PrivateRoutes = createBrowserRouter([
    {
      path: "/",
      element: <CatalogPage />,
      errorElement: <Error404Page />,
    },
    {
      path: "produto/:productID",
      element: <ViewProductPage />,
    },
    {
      path: "produtos/cadastro",
      element: <NewProductPage />,
    },
  ]);

  const PublicRoutes = createBrowserRouter([
    {
      path: "/",
      element: <WelcomePage />,
      errorElement: <Error404Page />,
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
      {isAuth && <NavBar isCompany={isCompany} />}

      <div className="p-5">
        <RouterProvider router={isAuth ? PrivateRoutes : PublicRoutes} />
      </div>

      {isAuth && <Footer />}
    </>
  );
}
