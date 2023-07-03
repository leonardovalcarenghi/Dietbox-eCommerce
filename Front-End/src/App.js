import logo from "./logo.svg";
import "./App.css";
import NavBar from "./Components/NavBar";
import Product from "./Components/Product";
import Footer from "./Components/Footer";
import { Routes } from "./Routes";
import { RouterProvider } from "react-router-dom";
import { useState } from "react";

function App() {
  const [isAuth, setIsAuth] = useState(false);

  return (
    <>
      <NavBar isAuth={isAuth} setIsAuth={setIsAuth} />

      <RouterProvider router={Routes} />

      <Footer />
    </>
  );
}

export default App;
