import React from "react";
import { Link } from "react-router-dom";
function NavBar() {
    return (<nav
        className="navbar navbar-expand-lg navbar-default navbar-dark"
        style={{ backgroundColor: "rgba(0,0,0,0.15)" ,textShadow:"0px 0px 0px black"}}
      >
        <div className="container-fluid">
          <Link  style={{marginLeft:"10px"}}className="navbar-brand  mb-lg-1" to="/">
            Home
          </Link>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mt-lg-2">
             
              <li className="nav-item">
                <Link style={{marginLeft:"10px"}} className="nav-link " to="/manage">
                  Manage
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>);
}
export default NavBar;