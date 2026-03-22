import React from "react";
import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import LoginPage from "../Pages/Authorization/LoginPage";
import Unathorize from "../Pages/Error Pages/Unathorize";
import Forbidden from "../Pages/Error Pages/Forbidden";
import ErrorPage from "../Pages/Error Pages/ErrorPage";

export const router = createBrowserRouter([
  {
    path: "",
    element: <App />,
    children: [],
  },
  {
    path: "/sign-in",
    element: <LoginPage />,
  },
  {
    path: "/unathorize",
    element: <Unathorize />,
  },
  {
    path: "/forbiidden",
    element: <Forbidden />,
  },

  {
    path: "*",
    element: <ErrorPage />,
  },
]);
