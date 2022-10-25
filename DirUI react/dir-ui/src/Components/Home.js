import React from "react";
import { Link } from "react-router-dom";
import {FolderService} from "../FolderService";
import Image from "../img/open-folder.png";
class Home extends React.Component {
  constructor(props) {
    super(props);
    this.root= null
    this.state = {
       root:{}
    };
  }
  componentDidMount() {
    let a =new FolderService();
    a.GetRoot().then((x) => {
        this.root= x
        this.setState({ root:this.root });
    });
    
  }
  render() {
    return (
      <>
        <div
          className="d-flex justify-content-center"
          style={{ marginTop: "10%" }}
        >
          <div className="d-flex flex-column">
            <div style={{ fontSize: "40px" }}>Get started!</div>
            <Link  style={{
           
           "font-size":  "30px",
            color: "white",
            "text-decoration": "none",

          }} to={"/dir/" + this.state.root.id}>
              <div>
                <img src={Image} style={{marginLeft:"35px"}} />
              </div>
              <div>{this.state.root.name}</div>
            </Link>
          </div>
        </div>
      </>
    );
  }
}
export default Home;
