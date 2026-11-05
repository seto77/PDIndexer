# Port of Crystallography/PeakSearch.cs PeakFunction value/derivative code; compare analytic vs finite-difference
import math
S=math.sqrt(math.log(2)*math.pi); SP=math.sqrt(math.log(2)/math.pi); L2=math.log(2); L15=math.sqrt(L2)*L2; PI=math.pi; SQ=math.sqrt(PI)
def pv(p,x):
    Int,eta,Hk,X=p; f=4*(x-X)**2/Hk/Hk
    return Int*((eta/PI/(1+f)+(1-eta)*SP*math.exp(-L2*f))*2/Hk)
def dpv(p,x):
    Int,eta,Hk,X=p; t3=4*(X-x)**2; t2=Hk*Hk; t1=t3/t2; t4=1/(1+t1); t5=S*math.exp(-L2*t1); t6=2/Hk/PI; e_=1-eta
    return [t6*(eta*t4+e_*t5), Int*t6*(t4-t5), -2*Int*(eta*(t2-t3)/PI/(t2+t3)**2+e_*(t2-2*t3*L2)/(t2*t2)*t5), Int*8*t6*(X-x)/t2*(-eta*t4*t4-e_*L2*t5)]
def pe(p,x):
    Int,Hk,m,X=p; a1=1/Hk;a2=2**(1/m); a3=x-X;a4=a2-1;a5=1+4*a1*a1*a3*a3*a4; return Int*a5**-m
def dpe(p,x):
    Int,Hk,m,X=p; a1=1/Hk;a2=2**(1/m); a3=x-X;a4=a2-1;a5=1+4*a1*a1*a3*a3*a4;a6=a5**-m
    return [a6,(8*a1**3*a3*a3*a4*a6*Int*m)/a5, a6*Int*((4*a2*a3*a3*L2)/((4*a3*a3*a4+Hk*Hk)*m)-math.log(a5)),(8*a1*a1*a3*a4*a6*Int*m)/a5]
def spv_par(p):
    Int,Hk,A,etaL,etaH,X=p; e=math.exp(A); Z1=1/e+1;Z2=e+1;a1=etaL-1;a2=etaH-1;a3=a1*S;a4=a2*S;a5=1/(etaL-a3);a6=1/(etaH-a4);a7=1/Hk;a8=a1*L15*SQ;a9=a2*L15*SQ
    return Z1,Z2,a1,a2,a3,a4,a5,a6,a7,a8,a9
def spv(p,x):
    Int,Hk,A,etaL,etaH,X=p; Z1,Z2,a1,a2,a3,a4,a5,a6,a7,a8,a9=spv_par(p); b=x-X
    if b<0:
        b1=b*b*a7*a7*Z1*Z1;b3=1/(1+b1);b5=2**-b1; return a5*(-a3*b5+b3*etaL)*Int
    b2=b*b*a7*a7*Z2*Z2;b4=1/(1+b2);b6=2**-b2; return a6*(-a4*b6+b4*etaH)*Int
def dspv(p,x):
    Int,Hk,A,etaL,etaH,X=p; Z1,Z2,a1,a2,a3,a4,a5,a6,a7,a8,a9=spv_par(p); b=x-X
    if b<0:
        b1=b*b*a7*a7*Z1*Z1;b3=1/(1+b1);b5=2**-b1
        return [a5*(-(a3*b5)+b3*etaL), 2*a5*a7**3*b*b*(-(a8*b5)+b3*b3*etaL)*Int*Z1*Z1, (2*a5*b1*(-(a8*b5)+b3*b3*etaL)*Int)/Z2,
          -((a5*a5*Int*S*((-1+b5)*Hk*Hk+b*b*b5*Z1*Z1))/(Hk*Hk+b*b*Z1*Z1)),0, 2*a5*a7*a7*b*(-(a8*b5)+b3*b3*etaL)*Int*Z1*Z1]
    b2=b*b*a7*a7*Z2*Z2;b4=1/(1+b2);b6=2**-b2
    return [a6*(-(a4*b6)+b4*etaH),2*a6*a7**3*b*b*(-(a9*b6)+b4*b4*etaH)*Int*Z2*Z2,(2*a6*b2*(a9*b6-b4*b4*etaH)*Int)/Z1,0,
        -((a6*a6*Int*S*((-1+b6)*Hk*Hk+b*b*b6*Z2*Z2))/(Hk*Hk+b*b*Z2*Z2)),2*a6*a7*a7*b*(-(a9*b6)+b4*b4*etaH)*Int*Z2*Z2]
def spe(p,x):
    Int,Hk,A,Rl,Rh,X=p; e=math.exp(A);Z1=1/e+1;Z2=e+1;a1=2**(1/Rl);a2=2**(1/Rh);a6=(a1-1)/Hk**2;a7=(a2-1)/Hk**2;b1=x-X
    return Int*(1+a6*b1*b1*Z1*Z1)**-Rl if b1<0 else Int*(1+a7*b1*b1*Z2*Z2)**-Rh
def dspe(p,x):
    Int,Hk,A,Rl,Rh,X=p; e=math.exp(A);Z1=1/e+1;Z2=e+1;a1=2**(1/Rl);a2=2**(1/Rh);a3=a1-1;a4=a2-1;a5=1/Hk;a6=a3*a5*a5;a7=a4*a5*a5;a8=Int*Z1*Z1;a9=Int*Z2*Z2;b1=x-X
    if b1<0:
        b2=1+a6*b1*b1*Z1*Z1;b4=b2**-Rl;b6=b1*b1*b4
        return [b4,(2*a5*a6*a8*b6*Rl)/b2,(2*a6*a8*b6*Rl)/(b2*Z2),(a1*a5*a5*a8*b6*L2)/(b2*Rl)-b4*Int*math.log(b2),0,(2*a6*a8*b1*b4*Rl)/b2]
    b3=1+a7*b1*b1*Z2*Z2;b5=b3**-Rh;b7=b1*b1*b5
    return [b5,(2*a5*a7*a9*b7*Rh)/b3,(-2*a7*a9*b7*Rh)/(b3*Z1),0,(a2*a5*a5*a9*b7*L2)/(b3*Rh)-b5*Int*math.log(b3),(2*a7*a9*b1*b5*Rh)/b3]
def fd(f,p,x,i,h=1e-6):
    q=list(p);r=list(p);s=max(abs(p[i]),1)*h;q[i]+=s;r[i]-=s;return (f(q,x)-f(r,x))/(2*s)
cases=[('PV [Int,eta,Hk,X]',pv,dpv,[100,0.4,0.2,30.0]),('Pearson [Int,Hk,m,X]',pe,dpe,[100,0.2,1.7,30.0]),
 ('SplitPV [Int,Hk,A,etaL,etaH,X]',spv,dspv,[100,0.2,0.3,0.4,0.6,30.0]),('SplitPearson [Int,Hk,A,Rl,Rh,X]',spe,dspe,[100,0.2,0.3,1.5,2.5,30.0])]
for name,f,df,p in cases:
    print(name)
    for x in [29.9,29.97,30.05,30.15]:
        a=df(p,x); n=[fd(f,p,x,i) for i in range(len(p))]
        print('  x=%.2f'%x, ' '.join('%d:%s'%(i,'ok' if abs(a[i]-n[i])<=1e-5*max(1,abs(n[i])) else 'NG(a=%.4g,n=%.4g,ratio=%.4g)'%(a[i],n[i],a[i]/n[i] if n[i] else float('nan'))) for i in range(len(p))))
# integrals
