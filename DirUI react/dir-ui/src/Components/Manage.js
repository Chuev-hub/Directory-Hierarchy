import React from "react";
import { Link } from "react-router-dom";
import { FolderService } from "../FolderService";
import Image from "../img/open-folder.png";
class Manage extends React.Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.download = this.download.bind(this);
    this.logFile = this.logFile.bind(this);
  }

  download() {
    let a = new FolderService();
    a.Get().then((x) => {
      let fileName = "dirs";
      let json = JSON.stringify(x, null, 2);
      let blob = new Blob([json], { type: "application/json" });
      let href = URL.createObjectURL(blob);
      let link = document.createElement("a");
      link.href = href;
      link.download = fileName + ".json";
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
      URL.revokeObjectURL(href);
    });
  }

  handleSubmit(event) {
    event.preventDefault();
    let file = document.querySelector("#file");
    if (!file.value.length) return;
    let reader = new FileReader();

    reader.onload = this.logFile;
    reader.readAsText(file.files[0]);
  }
  logFile(event) {
    
    let a = new FolderService();
    a.SetHierarchy(JSON.parse(event.target.result)).then((x) => {
        // Successful
          if(x.ok!=false)
          {
            document.getElementById("mark").innerHTML="Successful";
            document.getElementById("mark").style="color:#73ffab"
          }else{
            document.getElementById("mark").innerHTML="Follow rules";
            document.getElementById("mark").style="color:#ff4a4a"
          }
    })
  }
  render() {
    return (
      <>
        <div
          className="d-flex justify-content-center"
          style={{ marginTop: "10%", textAlign: "start" }}
        >
          <div  className="d-flex flex-column">
            <div style={{ fontSize: "40px" }}>
              You can upload custom hierarhy!
            </div>
            <div style={{ fontSize: "20px" }}>Just add it with some rules:</div>
            <div style={{ fontSize: "20px" }}>
              It should be JSON file with items that has properties:
            </div>
            <ul style={{ color: "cyan", marginTop: "10px" }}>
              <li>parentId (int)</li>
              <li>id (int)</li>
              <li>name (string)</li>
            </ul>
            <div style={{ color: "#ff4a4a", fontSize: "20px" }}>
              One (root) item should be with parentId=null !
            </div>
            <div>
              <form onSubmit={this.handleSubmit}>
                <input
                  id="file"
                  accept="application/JSON"
                  type="file"
                  style={{ width: "350px", marginTop: "20px" }}
                  className="form-control"
                />
                <div>
                  <button
                    type="submit"
                    style={{ width: "100px", marginTop: "10px" }}
                    className="btn btn-light"
                  >
                    Upload
                  </button>
                  <div id="mark"></div>
                </div>
              </form>
            </div>
            <br />
            <button
              style={{ width: "100px", marginTop: "10px" }}
              onClick={() => this.download()}
              className="btn btn-light"
            >
              Download
            </button>
          </div>
        </div>
      </>
    );
  }
}
export default Manage;
