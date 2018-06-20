<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<html> 
<body>
<div style="margin:50px">
  <h2 style="text-align:center">Wallet Functions</h2>

    <xsl:for-each select="doc/members/member">

    <xsl:choose>
    <xsl:when test="para !=''">
<hr />
        <h3 style="background:olive;color:white;text-align:center"><b><xsl:value-of select="para"/></b></h3>
<hr />
    </xsl:when>
    <xsl:otherwise>
        
<h4 style="color:green"><xsl:value-of select="@name"/></h4>

<ul>
  
<li style="color:teal"><b>Summary: </b></li>
<xsl:value-of select="summary"/>
<li style="color:teal"><b>Parameters: </b></li>
<xsl:value-of select="param"/>
<li style="color:teal"><b>Results: </b></li>
<xsl:value-of select="returns"/>
</ul>
    </xsl:otherwise>
</xsl:choose>


    </xsl:for-each>

 <div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>


