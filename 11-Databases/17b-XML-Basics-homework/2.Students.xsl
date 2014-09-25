<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />
  <xsl:template match="/">    
    <html>
      <header>
        <style>
          td {
          text-align: center;
          padding: 0 5px;
          }
        </style>
      </header>
      <body>
        <h2>Students</h2>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <tr bgcolor="#EEEEEE" padding="5">
            <td>
              <b>First Name</b>
            </td>
            <td>
              <b>Last Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birthday</b>
            </td>
            <td>
              <b>PhoneNumer</b>
            </td>
            <td>
              <b>E-mail</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Specialty</b>
            </td>
            <td>
              <b>Faculty Number</b>
            </td>
            <td>
              <b>Exams</b>
            </td>
          </tr>
          <xsl:for-each select="students/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="firstName"/>
              </td>
              <td>
                <xsl:value-of select="lastName"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birthday"/>
              </td>
              <td>
                <xsl:value-of select="phoneNumer"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="facultyNumber"/>
              </td>
              <td>
                <ul>
                  <xsl:for-each select="exams/exam">
                    <li>
                      <span>
                        <xsl:value-of select="name"/>
                      </span>
                      <span> - </span>
                      <span>
                        <xsl:value-of select="tutor"/>
                      </span>
                      <span> - </span>
                      <span>
                        <xsl:value-of select="score"/>
                      </span>
                    </li>
                  </xsl:for-each>
                </ul>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>

