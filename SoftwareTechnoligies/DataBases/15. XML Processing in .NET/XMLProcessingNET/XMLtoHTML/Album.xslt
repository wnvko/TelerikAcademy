<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <html>
      <body>
        <h2>My CD Collection</h2>
        <table border="0">
          <tr bgcolor="#999">
            <th align="left">Title</th>
            <th align="left">Artist</th>
            <th align="left">Year</th>
            <th align="left">Producer</th>
            <th align="left">Price</th>
          </tr>
          <xsl:for-each select="catalogue/album">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
            </tr>
            <tr>
              <td colspan ="5">
                <ul>
                  Songs:
                  <xsl:for-each select="songs">
                    <xsl:for-each select="title">
                      <li>
                        <span>
                          <xsl:value-of select="title" />
                        </span>
                      </li>
                    </xsl:for-each>
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
