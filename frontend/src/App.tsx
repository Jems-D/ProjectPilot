import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import { Layers } from "lucide-react";
import HeaderComponent from "./Components/HeaderComponent";
import FooterComponent from "./Components/FooterComponent";
import LoginPage from "./Pages/Authorization/LoginPage";

function App() {
  return (
    <>
      <div
        className="w-screen h-screen grid grid-cols-2
      bg-[url('/background.png')]"
      >
        <div
          className="grid h-screen"
          style={{ gridTemplateRows: "10% 80% 10%" }}
        >
          <header className="m-5 p-5">
            <HeaderComponent />
          </header>

          <div className="flex flex-row">Body</div>

          <footer className="m-5 p-5">
            <FooterComponent />
          </footer>
        </div>
        <div className="flex flex-col items-center justify-center">
          <LoginPage />
        </div>
      </div>
    </>
  );
}

export default App;
