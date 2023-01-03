Shader "Custom/cutout"
{
   SubShader
   {
      Tags{"Queue" = "Transparent+1"}
      Pass{
         Blend Zero One
         }
   }
}
