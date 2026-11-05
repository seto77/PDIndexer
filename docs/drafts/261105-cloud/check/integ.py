import sys,math; sys.path.insert(0,'.')
exec(open(__import__('os').path.join(__import__('os').path.dirname(__file__),'deriv.py')).read().split("cases=")[0])
from math import gamma,exp,sqrt,pi
def trap(f,p,X,w=400,n=400000):
    a=X-w;b=X+w;h=(b-a)/n;return sum(f(p,a+i*h) for i in range(n+1))*h - 0.5*h*(f(p,a)+f(p,b))
# code GetIntegral formulas
def gi_spv(p):
    Int,Hk,A,eL,eH,X=p; return Int*Hk*pi/2*(1/(1+exp(-A))/(eL+S*(1-eL))+1/(1+exp(A))/(eH+S*(1-eH)))
def gi_pe(p):
    Int,Hk,m,X=p; return Hk*Int*sqrt(pi)*gamma(m-0.5)/2/sqrt(2**(1/m)-1)/gamma(m)
def gi_spe(p):
    Int,Hk,A,Rl,Rh,X=p; gh1=gamma(Rh);gh2=gamma(Rh-.5);gl1=gamma(Rl);gl2=gamma(Rl-.5);a1=2**(1/Rl);a2=2**(1/Rh)
    return ((gh2/(sqrt(-1+a2)*gh1)+(A*gl2)/(sqrt(-1+a1)*gl1))*Hk*Int*sqrt(pi))/(2*(1+A))
for nm,f,g,p in [('PV(Int)',pv,lambda p:p[0],[100,0.4,0.2,30.]),('SplitPV',spv,gi_spv,[100,0.2,0.3,0.4,0.6,30.]),('Pearson',pe,gi_pe,[100,0.2,1.7,30.]),
   ('SplitPearson A=0.3',spe,gi_spe,[100,0.2,0.3,1.5,2.5,30.]),('SplitPearson A=0',spe,gi_spe,[100,0.2,0.0,1.5,2.5,30.])]:
    print(nm,'numeric=%.4f code=%.4f'%(trap(f,p,p[-1]),g(p)))
print('peak value at X:', pv([100,0.4,0.2,30.],30.), spv([100,0.2,0.3,0.4,0.6,30.],30.), pe([100,0.2,1.7,30.],30.))
