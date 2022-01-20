<%@ Page Title="Photo Gallery" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">	
div.img
  {
  margin:5px;
  padding: 5px;
  border:1px solid #0080ff;
  height:auto;
  width:auto;
  float:left;
  text-align:center;
  }
div.img img
  {
  display:inline;
  margin:5px;
  border:1px solid #000000;
  }
div.img a:hover img
  {
  border:1px solid #0000ff;
  }
div.desc
  {
  text-align:center;
  font-weight:normal;
  width:120px;
  margin:5px;
  }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table align="center">
    <tr align="center">
        <td align="center">
                <div class="img">
                  <a target="_blank" href="imgs/Slide1.jpg">
                  <img src="imgs/Slide1.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/Slide2.jpg">
                  <img src="imgs/Slide2.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>               
                <div class="img">
                  <a target="_blank" href="imgs/Slide4.jpg">
                  <img src="imgs/Slide4.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R1.jpg">
                  <img src="imgs/R1.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R2.jpg">
                  <img src="imgs/R2.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R3.jpg">
                  <img src="imgs/R3.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R4.jpg">
                  <img src="imgs/R4.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R5.jpg">
                  <img src="imgs/R5.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R6.jpg">
                  <img src="imgs/R6.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R7.jpg">
                  <img src="imgs/R7.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R8.jpg">
                  <img src="imgs/R8.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R9.jpg">
                  <img src="imgs/R9.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R10.jpg">
                  <img src="imgs/R10.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R11.jpg">
                  <img src="imgs/R11.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R12.jpg">
                  <img src="imgs/R12.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R13.jpg">
                  <img src="imgs/R13.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R14.jpg">
                  <img src="imgs/R14.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R15.jpg">
                  <img src="imgs/R15.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R16.jpg">
                  <img src="imgs/R16.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R17.jpg">
                  <img src="imgs/R17.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R18.jpg">
                  <img src="imgs/R18.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                
                <div class="img">
                  <a target="_blank" href="imgs/R19.jpg">
                  <img src="imgs/R19.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R20.jpg">
                  <img src="imgs/R20.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R21.jpg">
                  <img src="imgs/R21.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R22.jpg">
                  <img src="imgs/R22.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R23.jpg">
                  <img src="imgs/R23.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R24.jpg">
                  <img src="imgs/R24.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R25.jpg">
                  <img src="imgs/R25.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R26.jpg">
                  <img src="imgs/R26.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R27.jpg">
                  <img src="imgs/R27.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R28.jpg">
                  <img src="imgs/R28.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R29.jpg">
                  <img src="imgs/R29.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                
                <div class="img">
                  <a target="_blank" href="imgs/R31.jpg">
                  <img src="imgs/R31.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R32.jpg">
                  <img src="imgs/R32.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R33.jpg">
                  <img src="imgs/R33.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R34.jpg">
                  <img src="imgs/R34.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R35.jpg">
                  <img src="imgs/R35.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R36.jpg">
                  <img src="imgs/R36.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R37.jpg">
                  <img src="imgs/R37.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                
                <div class="img">
                  <a target="_blank" href="imgs/R38.jpg">
                  <img src="imgs/R38.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R39.jpg">
                  <img src="imgs/R39.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R40.jpg">
                  <img src="imgs/R40.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>  
                <div class="img">
                  <a target="_blank" href="imgs/R41.jpg">
                  <img src="imgs/R41.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R42.jpg">
                  <img src="imgs/R42.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R43.jpg">
                  <img src="imgs/R43.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                
                <div class="img">
                  <a target="_blank" href="imgs/R45.jpg">
                  <img src="imgs/R45.jpg" alt="Nkisa Hotels" width="110" height="90" />
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R46.jpg">
                  <img src="imgs/R46.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R47.jpg">
                  <img src="imgs/R47.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                
                <div class="img">
                  <a target="_blank" href="imgs/R48.jpg">
                  <img src="imgs/R48.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>
                <div class="img">
                  <a target="_blank" href="imgs/R49.jpg">
                  <img src="imgs/R49.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div>                                   
                <div class="img">
                  <a target="_blank" href="imgs/E13.jpg">
                  <img src="imgs/E13.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div> 
                <div class="img">
                  <a target="_blank" href="imgs/E7.jpg">
                  <img src="imgs/E7.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div> 
               <div class="img">
                  <a target="_blank" href="imgs/E4.jpg">
                  <img src="imgs/E4.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div> 
                <div class="img">
                  <a target="_blank" href="imgs/E10.jpg">
                  <img src="imgs/E10.jpg" alt="Nkisa Hotels" width="110" height="90"/>
                  </a>
                  <div class="desc"></div>
                </div> 
        </td>
    </tr>
</table>
  
</asp:Content>

