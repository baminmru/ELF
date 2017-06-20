<?php
class C_adrwin extends CI_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->_loadModels();
    }
	
    function getCountry()
    {
        log_message('debug', 'AdrWin.getCountry post : ' . json_encode($this->input->post(NULL, FALSE)));
        $country = $this->m_adrwin->getCountry();
        $return = array(
            'success' => (isset($country)) ? TRUE : FALSE,
            'data' => $country
        );
        print json_encode($return);
    }

    function getRegion()
    {
        log_message('debug', 'AdrWin.getRegion post : ' . json_encode($this->input->post(NULL, FALSE)));
        $aw_reg = $this->m_adrwin->getRegion();
        $return =  $aw_reg; /*array(
            'success' => (isset($aw_reg)) ? TRUE : FALSE,
            'data' => $aw_reg
        );*/
        print json_encode($return);
    }

	 function getCountryRegion()
    {
        log_message('debug', 'AdrWin.getRegion post : ' . json_encode($this->input->post(NULL, FALSE)));
		 $country = $this->input->get_post('country', TRUE);
		 
		 
		if (strlen($country) > 0) {
            $aw_reg = $this->m_adrwin->getCountryRegion($country);
            $return = $aw_reg; /*array(
                'success' => (isset($aw_reg)) ? TRUE : FALSE,
                'data' => $aw_reg
            );*/
        } else {
            $return = array(
                'success' => FALSE,
                'msg' => 'Need parent country to query.'
            );
        }
       
        print json_encode($return);
    }
    function getDistrict()
    {
        log_message('debug', 'AdrWin.getDistrict post : ' . json_encode($this->input->post(NULL, FALSE)));
        $region = $this->input->get_post('region', TRUE);
        if (strlen($region) > 0) {
            $aw_reg = $this->m_adrwin->getDistrict($region);
            $return =  $aw_reg; /*array(
                'success' => (isset($aw_reg)) ? TRUE : FALSE,
                'data' => $aw_reg
            ); */
        } else {
            $return = array(
                'success' => FALSE,
                'msg' => 'Need parent region to query.'
            );
        }
        print json_encode($return);
    }
    function getTown()
    { 
        log_message('debug', 'AdrWin.getTown post : ' . json_encode($this->input->post(NULL, FALSE)));
        $district = $this->input->get_post('district', TRUE);
        if (strlen($district) > 0) {
            $aw_tw = $this->m_adrwin->getTown($district);
            $return = $aw_tw; /*array(
                'success' => (isset($aw_tw)) ? TRUE : FALSE,
                'data' => $aw_tw
            );*/
        } else {
            $return = array(
                'success' => FALSE,
                'msg' => 'Need parent region to query.'
            );
        }
        print json_encode($return);
    }
	
    function getStreet()
    {
        log_message('debug', 'AdrWin.getStreet post : ' . json_encode($this->input->post(NULL, FALSE)));
        $find = isset($_REQUEST['find']) ? $_REQUEST['find'] : '';
        $node = isset($_REQUEST['node']) ? $_REQUEST['node'] : '';
        log_message('debug', 'AdrWin.getStreet get : ' . $node . ' ' . $find);
        $aw_reg = $this->m_adrwin->getStreet($node, $find);
        print json_encode($aw_reg);
    }

    function getTree()
    {
        log_message('debug', 'AdrWin.getTree post : ' . json_encode($this->input->post(NULL, FALSE)));
        //$node  =  $this->input->get_post('node', TRUE);
        $node = isset($_REQUEST['node']) ? $_REQUEST['node'] : '';
        log_message('debug', 'AdrWin.getTree node : ' . $node);
        $aw_tree = $this->m_adrwin->getTree($node);
        print json_encode($aw_tree);
    }

    private function _loadModels()
    {
        $this->load->model('M_adrwin', 'm_adrwin');
    }
	
	function Test(){

		$homepage = file_get_contents('http://main.groupsale.ru/forms/f.php');
		echo $homepage;
	}
	function Test2(){

		
		print json_encode("12345");
	}
}

?>
