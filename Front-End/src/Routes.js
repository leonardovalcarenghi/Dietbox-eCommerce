import { createBrowserRouter } from "react-router-dom";
import HomePage from "./Pages/Home";
import LoginPage from "./Pages/Login";
import RegisterPage from "./Pages/Register";
import ViewProductPage from "./Pages/ViewProduct";

export const Routes = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "login",
    element: <LoginPage />,
  },
  {
    path: "criar-conta",
    element: <RegisterPage />,
  },
  {
    path: "produto/:productID",
    element: <ViewProductPage />,
  },
]);
