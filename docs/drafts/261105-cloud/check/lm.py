# Mimic FitMultiPeaksThread (single PV peak + linear bg, unweighted, lambda 10, x0.5/x4) with code Jacobian vs corrected Jacobian
import math,random
exec(open(__import__('os').path.join(__import__('os').path.dirname(__file__),'deriv.py')).read().split("cases=")[0])
import numpy as np
def dpv_fix(p,x):
    d=dpv(p,x); Int,eta,Hk,X=p; t3=4*(X-x)**2;t2=Hk*Hk;t1=t3/t2;t4=1/(1+t1);t5=S*math.exp(-L2*t1)
    d[2]=-2*Int*(eta*(t2-t3)/PI/(t2+t3)**2+(1-eta)*(t2-2*t3*L2)/(t2*t2)*t5/PI); return d
def fit(xs,ys,p0,jac):
    p=np.array(p0,float); B=[min(ys),0.0]; cx=(xs[0]+xs[-1])/2
    def model(p,B): return np.array([pv(p,x)+B[0]+B[1]*(x-cx) for x in xs])
    r=ys-model(p,B); R=(r*r).sum(); lam=10; cnt=0
    while lam<1e9 and cnt<500:
        cnt+=1
        J=np.array([jac(p,x)+[1,x-cx] for x in xs])
        A=J.T@J; A[np.diag_indices_from(A)]*=1+lam; d=np.linalg.solve(A,J.T@r)
        pn=p+d[:4]; pn[1]=min(max(pn[1],0),1); Bn=[B[0]+d[4],B[1]+d[5]]
        if pn[2]<0: lam*=4; continue
        rn=ys-model(pn,Bn); Rn=(rn*rn).sum()
        if Rn<=R:
            lam*=0.5; p,B,r=pn,Bn,rn
            if cnt>50 and (R-Rn)/R<1e-10: break
            R=Rn
        else: lam*=4
    return p,R,cnt
random.seed(1)
true=[50.0,0.3,0.15,30.0]; xs=np.arange(29.5,30.5,0.005)
ys=np.array([pv(true,x)+20+5*(x-30)+random.gauss(0,math.sqrt(pv(true,x)+20)*0.05) for x in xs])/1000*1000
for nm,j in [('code jac',dpv),('fixed jac',dpv_fix)]:
    p,R,c=fit(xs,ys,[40,0.5,0.1,29.99],j); print(nm,'Int=%.4f eta=%.4f Hk=%.5f X=%.5f R=%.6g iter=%d'%(*p,R,c))
