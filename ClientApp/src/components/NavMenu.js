import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
                    <NavbarBrand>
                        <img  id ="tapmangologo" src={"https://www.tapmango.com/wp-content/uploads/thegem-logos/logo_84a6eea2d0e89632412968b006edc8ba_1x.png"} alt=""></img>
                    </NavbarBrand>
          </Container>
        </Navbar>
      </header>
    );
  }
}
