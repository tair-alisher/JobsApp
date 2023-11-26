"use client";

import React, { useState } from "react";
import "./Navbar.style.css";

const Navbar = () => {
  const [isVisible, setIsVisible] = useState<boolean>(false);

  return (
    <header className="header">
      <nav className="nav mcontainer">
        <a className="logo" href="#">
          Logo
        </a>

        <div className={`nav_menu ${isVisible && "show-menu"}`}>
          <ul className="nav_list">
            <li className="nav_item">
              <a href="#">Find job</a>
            </li>

            <li className="nav_item">
              <a href="#">Post job</a>
            </li>
          </ul>

          <div className="nav_close" onClick={() => setIsVisible(false)}>
            Close
          </div>
        </div>

        <div className="nav_actions">
          {/* theme button */}
          <div className="nav_toggle" onClick={() => setIsVisible(!isVisible)}>
            m
          </div>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
