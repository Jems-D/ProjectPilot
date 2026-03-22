import { Layers } from "lucide-react";
import React from "react";

const HeaderComponent = () => {
  return (
    <>
      <div className="flex flex-row justify-items-start align-middle gap-2">
        <div className="translate-3">
          <div className="w-10 h-10 flex items-center justify-center rounded-xl bg-[var(--grayCol2)]">
            <Layers color="#171717" className="size-5" />
          </div>
        </div>
        <div className="flex items-center justify-center translate-2">
          <span className="text-[var(--whiteCol)] text-3xl font-semibold">
            ProjectPilot
          </span>
        </div>
      </div>
    </>
  );
};

export default HeaderComponent;
