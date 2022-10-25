import React from "react";
import { Link } from "react-router-dom";
import {FolderService} from "../FolderService";
import Image from "../img/open-folder (2).png";
class Folder extends React.Component {
  constructor(props) {
    super(props);
    this.children= []
   
  }
 
  render() {
    return (
    
            <Link 
            
            style={{
           
            fontSize:  "30px",
            color: "white",
            "textDecoration": "none",

          }} to={"/dir/"+this.props.id }>
              <div>
                <img src={Image} style={{marginLeft:"35px"}} />
              </div>
              <div>{this.props.name}</div>
            </Link>
    );
  }
}
export default Folder;