<?php

namespace Calexo\CaMuMaBundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Template;
use Symfony\Component\Process\Process;

class DefaultController extends Controller
{
	const CAMUMA_SH_PATH = "~pi/camuma.sh";
	
    /**
     * @Route("/")
     * @Template()
     */
    public function indexAction()
    {
        return array( 'ret' => "" );
    }
    
    
    /**
     * @Route("/cmd", name="cmd")
     * @Route("/cmd/{action}", name="cmd.action")
     * 
     */
    public function cmdAction($action="status")
    {
    	switch ($action)
    	{
    		case "toggle":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." toggle");
    			break;
    		case "next":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." next");
    			break;
    		case "prev":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." prev");
    			break;
    		case "shuffle":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." shuffle");
    			break;
    		case "random":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." random");
    			break;
    		case "status":
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." status");
    			break;
    		default:
    			$ret=$this->camumaRun(self::CAMUMA_SH_PATH." status");
    			break;
    	}
    	return $this->render('CalexoCaMuMaBundle:Default:index.html.twig', array('ret' => $ret));
    }
    
    /**
     * @Route("id/{camumaid}", name="camumaid")
     * 
     */
    public function idAction($camumaid)
    {
    	if (strlen($camumaid)==6)
    	{
    		$ret=$this->camumaRun(self::CAMUMA_SH_PATH." ".$camumaid);
    	} else {
    		$ret="";
    	}
    	
    	return $this->render('CalexoCaMuMaBundle:Default:index.html.twig', array('ret' => $ret));
    }

    
    public function camumaRun($cmd)
    {
	    $process = new Process($cmd);
	    $process->setTimeout(3600);
	    $process->run();
	    if (!$process->isSuccessful()) {
	    	//throw new RuntimeException($process->getErrorOutput());
	    }
	    
	    return $process->getOutput();
    }
    
}
